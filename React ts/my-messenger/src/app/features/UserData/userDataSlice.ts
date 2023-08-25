import { createSlice } from "@reduxjs/toolkit";
import type { PayloadAction } from "@reduxjs/toolkit";


interface ILoginResponse{
    id:string
    accessToken:string,
    profilePicuteUrl:string,
}

interface UserState {
    user: ILoginResponse | null;
  }

  const initialState: UserState = {
    user: null,
  };


const userSlice = createSlice({
    name:'user',
    initialState,
    reducers: {
        setUser:(state,action: PayloadAction<ILoginResponse | null>)=>{
            state.user=action.payload;
        }
    }
});


export const setUserFromResponse = (response: ILoginResponse) => {
    return setUser({
        id: response.id,
        accessToken: response.accessToken,
        profilePicuteUrl: response.profilePicuteUrl,
    });
};


export const { setUser } = userSlice.actions;

export default userSlice.reducer;
