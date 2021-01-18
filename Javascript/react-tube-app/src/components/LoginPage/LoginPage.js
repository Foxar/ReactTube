import '../../App.css';
import HomeRoundedIcon from '@material-ui/icons/HomeRounded';
import { TextField, Button } from '@material-ui/core';

function LoginPage(props) {

    return (
        <div className="loginPage">
            <div className="loginForm">
                <TextField className="loginInput" label="Login" variant="filled" />
                <TextField className="loginInput" label="Password" type="password" variant="filled" />
                <Button variant="contained" color="primary" disableElevation>
                    Log in
                </Button>
            </div>
        </div>);
}

export default LoginPage;
