import React, { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom"; // Ensure react-router-dom is installed
import { jwtDecode } from "jwt-decode";  // ✅ Correct import
 // Ensure jwt-decode package is installed

const UserProfile = () => {
  const [user, setUser] = useState(null);
  const [error, setError] = useState("");
  const navigate = useNavigate(); // For redirecting to login

  useEffect(() => {
    const fetchUserProfile = async () => {
      const token = localStorage.getItem("token"); // Get token from localStorage

      if (!token) {
        setError("You are not logged in. Redirecting to login...");
        setTimeout(() => navigate("/"), 2000);
        return;
      }

      // Decode token to check expiration
      try {
        const decodedToken = jwtDecode(token);
        const currentTime = Date.now() / 1000; // Convert to seconds

        if (decodedToken.exp < currentTime) {
          setError("Session expired. Redirecting to login...");
          localStorage.removeItem("token");
          setTimeout(() => navigate("/login"), 2000);
          return;
        }
      } catch (err) {
        setError("Invalid token. Redirecting to login...");
        localStorage.removeItem("token");
        setTimeout(() => navigate("/login"), 2000);
        return;
      }

      try {
        const response = await fetch("http://localhost:5000/api/Users/current", {
          method: "GET",
          headers: {
            "Authorization": `Bearer ${token}`,
            "Content-Type": "application/json",
          },
        });

        if (response.status === 401) {
          throw new Error("Unauthorized! Your session may have expired.");
        }

        if (!response.ok) {
          throw new Error("Failed to fetch user profile.");
        }

        const data = await response.json();
        setUser(data);
      } catch (err) {
        setError(err.message);
      }
    };

    fetchUserProfile();
  }, [navigate]);

  if (error) {
    return <p className="text-danger">{error}</p>;
  }

  if (!user) {
    return <p>Loading...</p>;
  }

  return (
    <div className="container mt-4">
      <h2 className="text-primary">User Profile</h2>
      <p><strong>Name:</strong> {user.name}</p>
      <p><strong>Email:</strong> {user.email}</p>
    </div>
  );
};

export default UserProfile;
