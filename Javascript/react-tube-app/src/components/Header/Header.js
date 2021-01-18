import '../../App.css';
import HomeRoundedIcon from '@material-ui/icons/HomeRounded';
import { IconButton, TextField, Avatar } from '@material-ui/core';

function Header() {
    return (
        <div className="header">
            <div className="headerRow">
                <div className="headerCell">
                    <IconButton href="/">
                        <HomeRoundedIcon />
                    </IconButton>
                </div>
                <div className="headerCell">
                    <TextField className="searchInput" label="Search" variant="outlined" />
                </div>
                <div className="headerCell headerProfile">
                    <div className="avatarDiv">
                        <Avatar alt="User" ></Avatar>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Header;
