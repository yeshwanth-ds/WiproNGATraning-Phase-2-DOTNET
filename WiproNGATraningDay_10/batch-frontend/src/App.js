import React, { useState } from "react";
import { BrowserRouter as Router, Routes, Route, Navigate, Link } from "react-router-dom";
import Login from "./Login";
import BatchList from "./BatchList";
import UserProfile from "./UserProfile"; // Import User Profile Component
import "bootstrap/dist/css/bootstrap.min.css"; // Ensure Bootstrap is imported

function App() {
  const [token, setToken] = useState(localStorage.getItem("token"));

  const handleLogin = (newToken) => {
    localStorage.setItem("token", newToken);
    setToken(newToken);
  };

  const handleLogout = () => {
    localStorage.removeItem("token");
    setToken(null);
  };

  return (
    <Router>
      <div className="container mt-3">
        {token ? (
          <>
            {/* Navigation Menu */}
            <nav className="navbar navbar-expand-lg navbar-light bg-light mb-3">
              <div className="container-fluid">
                <span className="navbar-brand text-primary">Dashboard</span>
                <div className="collapse navbar-collapse">
                  <ul className="navbar-nav me-auto">
                    <li className="nav-item">
                      <Link className="nav-link" to="/profile">User Profile</Link>
                    </li>
                    <li className="nav-item">
                      <Link className="nav-link" to="/batches">Batch List</Link>
                    </li>
                  </ul>
                </div>
                <button className="btn btn-danger" onClick={handleLogout}>Logout</button>
              </div>
            </nav>

            {/* Routes */}
            <Routes>
              <Route path="/" element={<Navigate to="/profile" />} />
              <Route path="/profile" element={<UserProfile token={token} />} />
              <Route path="/batches" element={<BatchList />} />
            </Routes>
          </>
        ) : (
          <Routes>
            <Route path="/" element={<Login onLogin={handleLogin} />} />
            <Route path="*" element={<Navigate to="/" />} />
          </Routes>
        )}
      </div>
    </Router>
  );
}

export default App;
