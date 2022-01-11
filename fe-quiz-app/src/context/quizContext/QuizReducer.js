import * as actionTypes from './actionTypes';

const updateStateObject = (oldObject, updatedProprieties) => {
    return {
        ...oldObject,
        ...updatedProprieties
    };
};

const setQuizResponses = ( state, action ) => {
    console.log("quizResponses")
    console.log(action.payload)
    return updateStateObject( state, {
        quizResponses: action.payload
    } );
};


const QuizReducer = ( state, action ) => {
    switch ( action.type ) {
        case actionTypes.SET_QUIZ_RESPONSES: return setQuizResponses(state, action);
        default:
            return state;
    }
};

export default QuizReducer;