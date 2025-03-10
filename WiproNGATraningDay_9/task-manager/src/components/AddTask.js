import React, { useState } from "react";
import { useDispatch } from "react-redux";
import { addTask } from "../redux/taskSlice";
import { useNavigate } from "react-router-dom";

function AddTask() {
  const [task, setTask] = useState({ TaskId: "", TaskName: "", Description: "", Date: "", CreatedByUser: "" });
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();
    dispatch(addTask(task));
    navigate("/");
  };

  return (
    <form onSubmit={handleSubmit}>
      <input type="text" placeholder="Task ID" onChange={(e) => setTask({ ...task, TaskId: e.target.value })} required />
      <input type="text" placeholder="Task Name" onChange={(e) => setTask({ ...task, TaskName: e.target.value })} required />
      <input type="text" placeholder="Description" onChange={(e) => setTask({ ...task, Description: e.target.value })} />
      <input type="date" onChange={(e) => setTask({ ...task, Date: e.target.value })} />
      <input type="text" placeholder="Created By" onChange={(e) => setTask({ ...task, CreatedByUser: e.target.value })} />
      <button type="submit">Add Task</button>
    </form>
  );
}

export default AddTask;
