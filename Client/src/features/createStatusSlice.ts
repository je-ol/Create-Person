import { createSlice } from "@reduxjs/toolkit";

const createStatusSlice = createSlice({
  name: "createStatus",
  initialState: {
    isCreated: false,
  },
  reducers: {
    setCreated: (state) => {
      state.isCreated = true;
    },
    resetCreated: (state) => {
      state.isCreated = false;
    },
  },
});

export const { setCreated, resetCreated } = createStatusSlice.actions;
export default createStatusSlice.reducer;