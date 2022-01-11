import React, {Fragment} from 'react';
import {removeSpaces} from '../services/common';

const FormComponent = (props) => {
    const {question, type, handleChange} = props;

    return (
        <form>
            <p> {question.title} </p>
            {question.options.map((option) => {
                    return (
                        <Fragment>
                            <input 
                                type={type} 
                                id={question.id} 
                                name={type === 'checkbox' ? removeSpaces(option) : removeSpaces(question.title)} 
                                value={option}
                                onChange={handleChange}
                            />
                            <label for={removeSpaces(option)}>{option}</label> 
                            <br></br>
                        </Fragment>
                    )
                })
            }
        </form>
    )

}

export default FormComponent;