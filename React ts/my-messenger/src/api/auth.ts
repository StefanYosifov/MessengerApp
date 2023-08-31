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

const headers = {
    'Content-Type': 'application/json',
    'Accept':'*',
};

export const login = async (data: ILoginRequest): Promise<AxiosResponse<ILoginResponse>> => {
    try {
        console.log(data);
        console.log(`${baseUrl}/authenticate/login`);
        
        const response = await axios.post<ILoginResponse>(`${baseUrl}/authenticate/login`, data, { headers });
        return response;
    } catch (error) {
       console.log(error);
       throw error;
       
    }
};