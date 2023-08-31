import { Avatar, Box, Card, CardActionArea, CardContent, Divider, Typography } from "@mui/material";
import PersonAddIcon from "@mui/icons-material/PersonAdd";

const Friends = () => {
    return (
        <>
            <div className="w-96 h-screen">
                <header className="flex justify-between h-24 w-full border border-b px-4">
                    <Typography variant="h5">Chats</Typography>
                    <PersonAddIcon />
                </header>
                <section>
                    <Box >
                        <Card sx={{paddingY:'1px'}}>
                            <CardActionArea sx={{ display: 'flex', flexDirection: 'row', justifyContent: 'left'}}>
                                <Avatar
                                    src="https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png"
                                />
                                <Divider orientation="vertical" flexItem sx={{marginX:'1%'}}/>
                                <CardContent>
                                    <Typography variant="h6">
                                        Pesho
                                    </Typography>
                                </CardContent>
                            </CardActionArea>
                        </Card>
                        <Card sx={{ display: 'flex', flexDirection: 'column' }}>
                            <CardActionArea>
                                <Avatar
                                    src="https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png"
                                />
                                <CardContent>
                                    asd
                                </CardContent>
                            </CardActionArea>
                        </Card>
                    </Box>
                </section>
            </div>
        </>
    );
};

export default Friends;
