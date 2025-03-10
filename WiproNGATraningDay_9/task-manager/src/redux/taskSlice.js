import { createSlice } from "@reduxjs/toolkit";

const initialState = [];

const taskSlice = createSlice({
  name: "tasks",
  initialState,
  reducers: {
    addTask: (state, action) => {
      state.push(action.payload);
    },
    editTask: (state, action) => {
      const index = state.findIndex((task) => task.TaskId === action.payload.TaskId);
      if (index !== -1) {
        state[index] = action.payload;
      }
    },
    deleteTask: (state, action) => {
      return state.filter((task) => task.TaskId !== action.payload);
    },
  },
});

export const { addTask, editTask, deleteTask } = taskSlice.actions;
export default taskSlice.reducer;
