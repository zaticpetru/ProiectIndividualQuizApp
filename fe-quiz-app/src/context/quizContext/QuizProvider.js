import React, { useReducer } from 'react';

import QuizContext from './QuizContext';
import QuizReducer from './QuizReducer';

const QuizProvider = (props) => {
    const initialState = {
        quizResponses: {
            quizId: 0,
            questionResponses: []
        }
    };

    const [state, dispatch] = useReducer(QuizReducer, initialState);

    // const sendQuizData = (QuizData) => { dispatch({ type: 'SET_USER_INFO', payload: QuizData })};
    
    return (
        <QuizContext.Provider
            value={{
                quizResponses: state.quizResponses,
                dispatch
            }}
        >
            {props.children}
        </QuizContext.Provider>
    );
};

export default QuizProvider