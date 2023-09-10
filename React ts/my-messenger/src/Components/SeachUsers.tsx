import TextField from '@mui/material/TextField';
import Autocomplete from '@mui/material/Autocomplete';
import CircularProgress from '@mui/material/CircularProgress';
import { useEffect, useState } from 'react';
import { Search } from 'react-router-dom';
import { searchForFriendByName, sendFriendRequest } from '../api/friends';
import { setUser } from '../app/features/UserData/userDataSlice';
import { Avatar, Button, MenuItem, Typography } from '@mui/material';
import { Send } from '@mui/icons-material'

interface SearchedUsers {
  id: string,
  name: string,
  profilePicture: string
}

function sleep(delay = 0) {
  return new Promise((resolve) => {
    setTimeout(resolve, delay);
  });
}



const SearchUsers = () => {
  const [searchWord, setSearchWord] = useState('');
  const [open, setOpen] = useState(false);
  const [options, setOptions] = useState<readonly SearchedUsers[]>([]);
  const [users, setUsers] = useState<SearchedUsers[]>([]);
  const loading = open && options.length === 0;

  const onInputChange = async (_: React.SyntheticEvent<Element, Event>, value: string) => {
    setSearchWord(() => value);
  }

  useEffect(() => {
    let active = true;

    if (!loading) {
      return undefined;
    }

    (async () => {

      if (active) {
        setOptions([...users]);
      }
    })();

    return () => {
      active = false;
    };
  }, [loading]);

  useEffect(() => {
    if (!open) {
      setOptions([]);
    }
  }, [open]);

  useEffect(() => {
    if (searchWord.length < 3) {
      return;
    }
    const delayDebouncedFn = setTimeout(async () => {
      const response = await searchForFriendByName(searchWord);
      console.log(response);

      if (response.status === 200) {
        setUsers(() => response.data);
      }
    }, 1000);

    return () => clearTimeout(delayDebouncedFn);

  }, [searchWord]);


  return (
    <Autocomplete
      id="users"
      sx={{ width: 300 }}
      open={open}
      onOpen={() => {
        setOpen(true);
      }}
      onClose={() => {
        setOpen(false);
      }}
      isOptionEqualToValue={(option, value) => option.name === value.name}
      getOptionLabel={(option) => option.name}
      renderOption={(props, option) => {
        return (
          <MenuItem sx={{display:'flex',justifyContent:'space-between'}}>
            <Avatar src={option.profilePicture} />
            <Typography variant='h6'>{option.name}</Typography>
            <Button variant="contained" endIcon={<Send onClick={()=>sendFriendRequest(option.id)} />} size='small'>
            </Button>
          </MenuItem>
        )
      }}
      options={options}
      loading={loading}
      onInputChange={(event, value) => onInputChange(event, value)}
      renderInput={(params) => (
        <TextField
          {...params}
          label="Users"
          InputProps={
            {
              ...params.InputProps,
              endAdornment: (
                <>
                  {loading ? <CircularProgress color="inherit" size={20} /> : null}
                  {console.log(params.InputProps.endAdornment)}
                  {params.InputProps.endAdornment}
                </>
              ),
            }}
        />
      )}
    />
  );
}

export default SearchUsers;