import React, {useEffect, useContext} from 'react';
import Question from './Question';
import { useParams } from "react-router-dom";
import Button from './Button';
import QuizContext from '../context/quizContext/QuizContext';


const Quiz = () => {

    let params = useParams();

    const quizId = params.quizId;

    // console.log(params.quizId)

    const {quizResponses, dispatch} = useContext(QuizContext);
    
    useEffect(() => {
        dispatch({type: 'SET_QUIZ_RESPONSES', payload: {...quizResponses, quizId: quizId} })
    }, [quizId]);

    const dummyData = [
        {
            id: '1',
            title: 'Who is the love?',
            type: 'open',
        },
        {
            id: '2',
            title: 'Why is the love?',
            type: 'multiple',
            options: ['because', 'other because', 'yet another because']
        }, 
        {
            id: '3',
            title: 'Where is the love?',
            type: 'single',
            options: ['here', 'somewhere else', 'dunno']

        }
    ];

    return (
        <div>
            {dummyData.map((question, index) => {
                return <Question key={index} question={question} />
            })}
            <Button> Submit responses </Button>
        </div>
    )
}

export default Quiz;