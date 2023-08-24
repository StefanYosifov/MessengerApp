import { Controller, SubmitHandler, useForm } from 'react-hook-form';
import { Button, Checkbox, FormLabel, Typography, TextField, Card, CardContent } from "@mui/material"
import { useRef } from 'react';

interface IFormInput {
    userName: string;
    email: string;
    password: string;
    repeatPassword: string;
    remember: false;
};

interface IForm {
    variant: boolean;
    setVariant: React.Dispatch<React.SetStateAction<boolean>>;
}

const RegisterForm: React.FC<IForm> = ({ variant, setVariant }) => {

    const { control, handleSubmit, formState: { errors, isSubmitting }, reset } = useForm<IFormInput>({
        defaultValues: {
            userName: '',
            email: '',
            password: '',
            repeatPassword: '',
            remember: false,
        }
    });

    let refPassword = useRef<HTMLInputElement | null>(null);

    const onSubmit: SubmitHandler<IFormInput> = data => {
        console.log(data)
        reset();
    };

    return (
        <div className='w-96'>
            <Card>
                <CardContent>
                    <Typography variant='h6' color='ActiveCaption' sx={{ mb: 6 }}>Welcome to messenger</Typography>
                    <form onSubmit={handleSubmit(onSubmit)} className='flex flex-col gap-y-8'>
                        <Controller
                            name='userName'
                            control={control}
                            rules={{
                                required: 'Username is required',
                                maxLength: {
                                    message: 'Maximum of 50 characters allowed',
                                    value: 50
                                },
                                minLength: {
                                    message: 'Minimum of 4 characters allowed',
                                    value: 4
                                }
                            }}
                            render={({ field }) => <TextField id='userName' label='Username' {...field} />}
                        />
                        <Controller
                            name='email'
                            control={control}
                            rules={{
                                required: 'Email is required',
                                maxLength: {
                                    message: 'Maximum of 50 characters allowed',
                                    value: 50
                                },
                                minLength: {
                                    message: 'Minimum of 4 characters allowed',
                                    value: 4
                                }
                            }}
                            render={({ field }) => <TextField id='userName' label='Email' {...field} />}
                        />
                        {errors.userName?.message &&
                            <FormLabel color='warning' >{errors.userName.message}</FormLabel>}

                        <Controller
                            name='password'
                            control={control}
                            rules={{
                                required: 'Password is required',
                                maxLength: {
                                    message: 'Maximum of 50 characters allowed',
                                    value: 50
                                },
                                minLength: {
                                    message: 'Minimum of 6 characters allowed',
                                    value: 6
                                }
                            }}
                            render={({ field }) => <TextField type='password' label='Password' {...field} ref={refPassword} />}
                        />
                        {errors.password?.message &&
                            <FormLabel color='warning' >{errors.password.message}</FormLabel>}
                        <Controller
                            name='repeatPassword'
                            control={control}
                            rules={{
                                validate: (value) => value === refPassword.current?.value || 'Passwords do not match',
                                required: 'Repeated password is required',
                                maxLength: {
                                    message: 'Maximum of 50 characters allowed',
                                    value: 50
                                },
                                minLength: {
                                    message: 'Minimum of 6 characters allowed',
                                    value: 6
                                }
                            }}
                            render={({ field }) => <TextField type='password' label='Repeat password' {...field} />}
                        />
                        <Button type='submit' variant='contained' disabled={isSubmitting}>Submit</Button>
                        <div className='flex'>
                            <Controller
                                name='remember'
                                control={control}
                                render={({ field }) => <Checkbox id='remember' {...field} />}
                            />
                            <FormLabel htmlFor='remember'>Remember me</FormLabel>
                        </div>
                        <Typography>
                            <Button onClick={() => setVariant(!variant)}>
                                Already have an account? Click here to sign in
                            </Button>
                        </Typography>
                    </form>
                </CardContent>
            </Card>
        </div>
    );
}

export default RegisterForm;