import { Avatar, Box, Card, CardActionArea, CardContent, Divider, Typography } from "@mui/material";
import PersonAddIcon from "@mui/icons-material/PersonAdd";
import SearchUsers from "./SeachUsers";
import { useEffect, useState } from "react";
import CloseIcon from '@mui/icons-material/Close';
import { RootState, useAppDispatch, useAppSelector } from "../app/store";
import { getAllFriends } from "../app/features/friendsSlice";

const Friends = () => {

    const [openSearchUsers, setOpenSearchUsers] = useState(false);
    const dispatch = useAppDispatch();
    const friends = useAppSelector((state: RootState) => state.friends);

    useEffect(() => {
        dispatch(getAllFriends());
    }, [dispatch]);

    const changeOpenCloseSearchBar = () => {
        setOpenSearchUsers(!openSearchUsers)
    };

    console.log(friends);

    return (
        <>
            <div className="w-96 h-screen">
                <header className="flex justify-between h-24 w-full border border-b px-4">
                    <Typography variant="h5">Chats</Typography>
                    {openSearchUsers === true ?
                        <>
                            <SearchUsers />
                            <CloseIcon onClick={changeOpenCloseSearchBar} />
                        </>
                        :
                        <PersonAddIcon onClick={changeOpenCloseSearchBar} />
                    }
                </header>
                <section>
                    <Box >
                        {friends ? friends.map(friend=>
                            <>
                                <Card sx={{ paddingY: '1px' }}>
                                    <CardActionArea sx={{ display: 'flex', flexDirection: 'row', justifyContent: 'left' }}>
                                        <Avatar
                                            src={`${friend.friendProfilePicture}`}
                                        />
                                        <Divider orientation="vertical" flexItem sx={{ marginX: '1%' }} />
                                        <CardContent>
                                            <Typography variant="h6">
                                                {friend.friendName}
                                            </Typography>
                                        </CardContent>
                                    </CardActionArea>
                                </Card>
                            </>
                        ) : ''}
                    </Box>
                </section>
            </div>
        </>
    );
};

export default Friends;
