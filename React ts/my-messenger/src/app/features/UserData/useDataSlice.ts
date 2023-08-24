import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";


export interface UserState={
    token ? : string;
    profileUrl: string;
}

const initialValue: UserState = {
    token: null,
    profileUrl: null
};


export const userStateSlice = createSlice({
    name:'user',
    initialState:initialValue,
    reducers: {
        
    }
})
