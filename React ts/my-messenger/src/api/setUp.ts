import axios from "axios";

export function setToken(token:string) {
    axios.defaults.headers.common['Authorization'] =
        `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoicGVzaG8iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImIyZTU4ZmI3LTJiZmQtNGY5Yi05OGEzLTJkNjFkYTZjZmI0NSIsImp0aSI6IjVhYzViODE3LWYyY2QtNGI0ZC05ZmVhLTcxNjc1NGIzZDI5NiIsImV4cCI6MTY5NDM0NjM5NiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo0OTYyNSIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NDIwMCJ9.VUAm_iaZS7h2bU2Rhqd7ICm7PcutonZCILOeiDrmPV8`;
  }