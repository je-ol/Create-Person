import { createSlice } from "@reduxjs/toolkit";

const searchStatusSlice = createSlice({
  name: "searchStatus",
  initialState: {
    isSearched: false,
  },
  reducers: {
    setSearched: (state) => {
      state.isSearched = true;
    },
    resetSearched: (state) => {
      state.isSearched = false;
    },
  },
});

export const { setSearched, resetSearched } = searchStatusSlice.actions;
export default searchStatusSlice.reducer;