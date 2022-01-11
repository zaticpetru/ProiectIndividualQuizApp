import React, { Suspense, lazy } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import AuthProvider from './context/authContext/AuthProvider';
import QuizProvider from './context/quizContext/QuizProvider';
import ErrorBoundary from './components/ErrorBoundary';
import Home from './pages/Home'
import Signin from './pages/Signin'
import QuizPage from './pages/QuizPage';
import Quiz from './components/Quiz';
import './App.css';

function App() {
  return (
    <ErrorBoundary>
      <AuthProvider>
        <QuizProvider>
          <Router>
            <Routes>
                <Route index path="/" element={<Home/>} />
                <Route path="/quiz" element={<QuizPage/>} />
                <Route path="quiz/:quizId" element={<Quiz />} />
                {/* <Route path="/about" component={About}/> */}
                <Route path="/signin" element={<Signin/>}/>
            </Routes>
          </Router>
        </QuizProvider>
      </AuthProvider>
    </ErrorBoundary>

  );
}

export default App;
