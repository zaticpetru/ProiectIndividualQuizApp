import React, { Suspense, lazy } from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import AuthProvider from './context/authContext/AuthProvider';
import ErrorBoundary from './components/ErrorBoundary';
import Home from './components/Home'
import './App.css';

// const Home = lazy(() => import('./components/Home'));
const About = lazy(() => import('./components/About'));
const Signin = lazy(() => import('./components/Signin'));

function App() {
  return (
    <ErrorBoundary>
      <AuthProvider>
        <Router>
          <Suspense fallback={<div>Loading...</div>}>
            <Switch>
              <Route exact path="/" component={Home}/>
              <Route path="/about" component={About}/>
              <Route path="/signin" component={Signin}/>
            </Switch>
          </Suspense>
        </Router>
      </AuthProvider>
    </ErrorBoundary>

  );
}

export default App;
