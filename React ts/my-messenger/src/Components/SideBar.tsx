import PeopleIcon from '@mui/icons-material/People';
import GroupsIcon from '@mui/icons-material/Groups';





const SideBar = () => {

    const cursor = { cursor: 'pointer' };


    return (
        <div className='flex flex-col items-start bg-slate-200 h-screen w-8'>
            <div className='flex flex-col gap-y-2 items-center'>
                <PeopleIcon sx={{ ":hover": cursor }} />
                <GroupsIcon sx={{ ":hover": cursor }} />
            </div>
        </div>
    )
}


export default SideBar;