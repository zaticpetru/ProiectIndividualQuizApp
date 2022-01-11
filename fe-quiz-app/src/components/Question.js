import React, {useContext} from 'react';
import FormComponent from './FormComponent';
import {removeSpaces} from '../services/common';
import QuizContext from '../context/quizContext/QuizContext';

const Question = ({question}) => {

    const {quizResponses, dispatch} = useContext(QuizContext);

    const handleChange = (event) => {
        const questionId = event.target.id;
        const questionResponse = event.target.value;

        let responsesArray = [...quizResponses.questionResponses];
        
        if (responsesArray.some(e => e.questionId === questionId)) {
            const index = responsesArray.findIndex(e => e.questionId === questionId);
            if (question.type === 'multiple') {
                if (responsesArray[index].response.includes(questionResponse)) {
                    const indexOfExistingResponse = responsesArray[index].response.findIndex(e => e === questionResponse);
                    responsesArray[index].response.splice(indexOfExistingResponse, 1);
                } else {
                    responsesArray[index].response = [...responsesArray[index].response, questionResponse];
                }
            } else {
                responsesArray[index].response = [questionResponse];
            }
        } else {
            responsesArray = [...responsesArray, {questionId: questionId, response: [questionResponse]}];
        }

        dispatch({type: 'SET_QUIZ_RESPONSES', 
        payload: {...quizResponses, questionResponses: responsesArray}})
    }

    const createQuestion = () => {
        switch (question.type) {
            case 'open':
                return (
                <form>
                    <label htmlFor={removeSpaces(question.title)}>
                        {question.title}
                    </label>
                    <br></br>
                    <input onChange={handleChange} type="text" className='text-black' id={question.id} name={removeSpaces(question.title)}/>
                </form>
                ) 
            case 'single':
            
                return <FormComponent handleChange={handleChange} question={question} type={'radio'}/>

            case 'multiple':

                return <FormComponent handleChange={handleChange} question={question} type={'checkbox'}/>
                
            default:
                return null
        }
    }

    return (
        <div>
            {createQuestion()}
        </div>
    )
}

export default Question;