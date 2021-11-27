import React, { Suspense, lazy } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import AuthProvider from './context/authContext/AuthProvider';
import ErrorBoundary from './components/ErrorBoundary';
import Home from './components/Home'
import Signin from './components/Signin'
import './App.css';

function App() {
  return (
    <ErrorBoundary>
      <AuthProvider>
        <Router>
            <Routes>
                <Route index path="/" element={<Home/>} />
                {/* <Route path="/about" component={About}/> */}
                <Route path="/signin" element={<Signin/>}/>
            </Routes>
        </Router>
      </AuthProvider>
    </ErrorBoundary>

  );
}

export default App;
