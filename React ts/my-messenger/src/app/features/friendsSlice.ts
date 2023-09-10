import { createSlice, PayloadAction, createAsyncThunk, isAsyncThunkAction } from "@reduxjs/toolkit";
import AppThunk from "../store";
import { getFriends } from "../../api/friends";

interface IFriendShip {
    friendShipId: number;
    friendName: string;
    friendProfilePicture?: string | null;
}

const initialState: IFriendShip[] = [];

export const getAllFriends = createAsyncThunk('friends/all', async () => {
    const response = await getFriends();
    return response.data;
});


const friendsSlice = createSlice({
    name: 'friends',
    initialState,
    reducers: {
        addFriend: (state, action: PayloadAction<IFriendShip>) => {
            state.push(action.payload);
        },
        loadFriends: (state, action: PayloadAction<IFriendShip>) => {
        }
    },
    extraReducers(builder) {
        builder.addCase(getAllFriends.fulfilled, (state, action:any) => {
            return [...action.payload];
        });
    }
});

export const { addFriend } = friendsSlice.actions;

export default friendsSlice.reducer;
