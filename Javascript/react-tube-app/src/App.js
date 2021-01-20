import './App.css';
import VideoPlayer from './components/VideoPlayer/VideoPlayer'
import VideoPage from './components/VideoPage/VideoPage'
import LoginPage from './components/LoginPage/LoginPage'
import RegisterPage from './components/RegisterPage/RegisterPage'
import Header from './components/Header/Header'
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";



function App() {
  return (
    <div className="App">
      <Header />
      <Router>
        <Switch>
          <Route path="/login">
            <LoginPage />
          </Route>
          <Route path="/register">
            <RegisterPage />
          </Route>
          <Route path="/video/:urlName">
            <VideoPage />
          </Route>
          <Route path="/video/:urlName">
            <VideoPlayer />
          </Route>
          <Route path="/testvideopage">
            <VideoPlayer />
          </Route>
          <Route path="/">
            <ul style={{ paddingTop: '6em' }}>
              <li><Link to="/video/7SXNeaGkn0GxZE5g0YblHg">Video1</Link></li>
              <li><Link to="/video/Chs8v1hKJk27Q9NAq5-wtg">Video2</Link></li>
              <li><Link to="/video/k_HSnEOTzkKgrA5GkqZ6yQ">Video3</Link></li>
              <li><Link to="/login">Log in</Link></li>
              <li><Link to="/register">Register</Link></li>
            </ul>
            <h1>Welcome to ReactTube</h1>
          </Route>
        </Switch>
      </Router>
    </div>
  );
}

export default App;
