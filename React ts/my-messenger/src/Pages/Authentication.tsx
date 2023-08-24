import { useState } from "react"
import LoginForm from "../Components/LoginForm";
import RegisterForm from "../Components/RegisterForm";



export default function Authentication(){
    const [variant, setVariant] = useState(true);

    {console.log(variant)}
    return (
      <div className="flex justify-center items-center">
        {variant ? 
        <LoginForm variant={variant} setVariant={setVariant} /> : 
        <RegisterForm variant={variant} setVariant={setVariant}/>}
      </div>
    );
}