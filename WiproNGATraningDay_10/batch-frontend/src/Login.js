import React, { useState } from "react";
import "bootstrap/dist/css/bootstrap.min.css"; // Ensure Bootstrap is imported

const Login = ({ onLogin }) => {
  const [email, setEmail] = useState("user@example.com");
  const [password, setPassword] = useState("password123");
  const [error, setError] = useState("");
  const [showModal, setShowModal] = useState(false);

  const handleLogin = async () => {
    try {
      const response = await fetch("http://localhost:5000/api/Authentication", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ email, password }),
      });

      const data = await response.json();
      if (data.token) {
        onLogin(data.token);
      } else {
        setError("Invalid credentials");
        setShowModal(true); // Show modal when credentials are invalid
      }
    } catch (err) {
      setError("Error logging in");
      setShowModal(true); // Show modal on error
    }
  };

  return (
    <div className="container mt-5">
      <div className="card p-4 mx-auto" style={{ maxWidth: "400px" }}>
        <h2 className="text-center text-primary">Login</h2>
        {error && <p className="text-danger text-center">{error}</p>}
        <div className="mb-3">
          <label className="form-label">Email</label>
          <input
            type="email"
            className="form-control"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            placeholder="Enter email"
          />
        </div>
        <div className="mb-3">
          <label className="form-label">Password</label>
          <input
            type="password"
            className="form-control"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            placeholder="Enter password"
          />
        </div>
        <button className="btn btn-primary w-100" onClick={handleLogin}>
          Login
        </button>
      </div>

      {/* Bootstrap Modal */}
      {showModal && (
        <div className="modal fade show d-block" tabIndex="-1" role="dialog">
          <div className="modal-dialog" role="document">
            <div className="modal-content">
              <div className="modal-header">
                <h5 className="modal-title text-danger">Login Failed</h5>
                <button type="button" className="btn-close" onClick={() => setShowModal(false)}></button>
              </div>
              <div className="modal-body">
                <p>Invalid credentials. Please try again.</p>
              </div>
              <div className="modal-footer">
                <button className="btn btn-secondary" onClick={() => setShowModal(false)}>
                  Close
                </button>
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default Login;
