import React from "react";
import { useSelector, useDispatch } from "react-redux";
import { deleteTask } from "../redux/taskSlice";
import { Link } from "react-router-dom";

function TaskList() {
  const tasks = useSelector((state) => state.tasks);
  const dispatch = useDispatch();

  return (
    <div>
      <h2>Task List</h2>
      <Link to="/add">Add New Task</Link>
      <ul>
        {tasks.map((task) => (
          <li key={task.TaskId}>
            {task.TaskName} - {task.Description} - {task.Date} - {task.CreatedByUser}
            <Link to={`/edit/${task.TaskId}`}>Edit</Link>
            <button onClick={() => dispatch(deleteTask(task.TaskId))}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default TaskList;
