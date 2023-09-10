import { createSlice } from "@reduxjs/toolkit";

interface IUser {
    isAuthenticated: boolean
    userInfo: {
        id?: string | null,
        token?:string | null
        profilePicture?:string | null,
    }
}

const userJson = localStorage.getItem('user');
const initialState: IUser = {
    userInfo: {
        id: null,
        token: null,
        profilePicture: null,
    },
    isAuthenticated: userJson ? true : false,
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
            state.userInfo = {};
            localStorage.removeItem('user');
        }
    }
})


export const { setCredentials, logout } = authSlice.actions;
export default authSlice.reducer;