import axios, { AxiosResponse } from "axios"
import { baseUrl } from "../constants/constants";

interface ILoginRequest{
    userName:string,
    password:string,
}

interface ILoginResponse{
    id:string
    accessToken:string,
    profilePicuteUrl:string,
}

const headers={
    'Authorization' : '',
    'Content-type' : 'application/json',
    'Access-Control-Allow-Origin': '*'
};

export const login = async (data: ILoginRequest): Promise<AxiosResponse<ILoginResponse>> => {
    try {
        const response = await axios.post<ILoginResponse>(`${baseUrl}/authenticate/login`, data,{headers});
        return response;
    } catch (error) {
       throw error;
    }
};