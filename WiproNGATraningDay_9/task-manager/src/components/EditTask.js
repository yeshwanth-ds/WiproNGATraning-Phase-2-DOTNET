import React, { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { editTask } from "../redux/taskSlice";
import { useNavigate, useParams } from "react-router-dom";

function EditTask() {
  const { id } = useParams();
  const tasks = useSelector((state) => state.tasks);
  const existingTask = tasks.find((task) => task.TaskId === id);
  const [task, setTask] = useState(existingTask);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();
    dispatch(editTask(task));
    navigate("/");
  };

  return (
    <form onSubmit={handleSubmit}>
      <input type="text" value={task.TaskName} onChange={(e) => setTask({ ...task, TaskName: e.target.value })} required />
      <input type="text" value={task.Description} onChange={(e) => setTask({ ...task, Description: e.target.value })} />
      <input type="date" value={task.Date} onChange={(e) => setTask({ ...task, Date: e.target.value })} />
      <input type="text" value={task.CreatedByUser} onChange={(e) => setTask({ ...task, CreatedByUser: e.target.value })} />
      <button type="submit">Update Task</button>
    </form>
  );
}

export default EditTask;
