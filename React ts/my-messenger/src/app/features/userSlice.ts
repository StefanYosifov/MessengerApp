import { createSlice } from "@reduxjs/toolkit";

interface IUser {
    isAuthenticated: boolean
    userInfo: string | null;
}

const userJson = localStorage.getItem('user');
const initialState: IUser = {
    userInfo: userJson
        ? JSON.parse(userJson) as string | null
        : null,
    isAuthenticated: userJson ? true : false
};

const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        setCredentials: (state, action) => {
            state.userInfo = action.payload;
            state.isAuthenticated=true;
            localStorage.setItem('user', JSON.stringify(action.payload))
        },
        logout: (state, action) => {
            state.userInfo = null;
            localStorage.removeItem('user');
        }
    }
})


export const { setCredentials, logout } = authSlice.actions;
export default authSlice.reducer;