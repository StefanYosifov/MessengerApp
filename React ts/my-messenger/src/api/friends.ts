import axios, { AxiosResponse } from "axios"
import { baseUrl } from "../constants/constants"
import { get, post } from "./api"


interface SearchedUsers {
    id: string,
    name: string,
    profilePicture: string
}

interface IFriendShip {
    FriendShip: number;
    FriendName: string;
    FriendProfilePicture?: string | null;
}

const URLS = {
    SEARCH_FOR_FRIEND : 'friends/searchFriend',
    GET_FRIENDS:'friends/all',
    SEND_FRIEND_REQUEST:'friends/send'
}

export const searchForFriendByName = async (name: string): Promise<AxiosResponse<SearchedUsers[]>> => {
    return await get(`${URLS.SEARCH_FOR_FRIEND}/query?userName=${name}`);
}

export const getFriends = async():Promise<AxiosResponse<IFriendShip[]>> => {
    return await get(`${URLS.GET_FRIENDS}`);
}

export const sendFriendRequest= async(userId:string):Promise<AxiosResponse<string>> =>{
    return await post(`${URLS.SEND_FRIEND_REQUEST}`,{userId});
}