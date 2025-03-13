import React, { useEffect, useState } from "react";

const BatchList = () => {
  const [batches, setBatches] = useState([]);
  const token = localStorage.getItem("token");

  useEffect(() => {
    if (token) {
      fetch("http://localhost:5000/api/Batch", {
        headers: { Authorization: `Bearer ${token}` },
      })
        .then((res) => res.json())
        .then((data) => setBatches(data))
        .catch(() => console.error("Failed to fetch batches"));
    }
  }, [token]);

  return (
    <div className="container mt-4">
      <h2 className="text-primary">Batch List</h2>
      <table className="table table-bordered table-striped">
        <thead className="table-dark">
          <tr>
            <th>Batch ID</th>
            <th>Name</th>
            <th>Start Date</th>
            <th>Seats</th>
            <th>Created By</th>
            <th>Created On</th>
            <th>Updated By</th>
            <th>Updated On</th>
            <th>Is Active</th>
          </tr>
        </thead>
        <tbody>
          {batches.map((batch) => (
            <tr key={batch.batchId}>
              <td>{batch.batchId}</td>
              <td>{batch.name}</td>
              <td>{new Date(batch.startDate).toLocaleDateString()}</td>
              <td>{batch.seats}</td>
              <td>{batch.createdBy}</td>
              <td>{new Date(batch.createdOn).toLocaleString()}</td>
              <td>{batch.updatedBy ?? "N/A"}</td>
              <td>{batch.updatedOn ? new Date(batch.updatedOn).toLocaleString() : "N/A"}</td>
              <td>
                <span className={`badge ${batch.isActive ? "bg-success" : "bg-danger"}`}>
                  {batch.isActive ? "Active" : "Inactive"}
                </span>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default BatchList;
