import React, { Fragment, useContext, useState } from 'react';
import { Formik, Form, Field, ErrorMessage } from 'formik';
import AuthContext from '../context/authContext/AuthContext';


const Signin = () => {

    const [isSignUpForm, setIsSignUpForm] = useState(false);

    const {user, dispatch} = useContext(AuthContext);

    const sendSignUpData = (values) => {
        const userInfo = {
            email: values.email,
            password: values.password,
        }
        dispatch({type: 'SET_USER_INFO', payload: userInfo })
    }

    const linkToForm = isSignUpForm ? 
    ( <button 
        onClick={() => setIsSignUpForm(false)}
        className="font-medium text-pink-500 hover:text-pink-400">
        log in
    </button> ) : 
    (
        <button 
        onClick={() => setIsSignUpForm(true)}
        className="font-medium text-pink-500 hover:text-pink-400">
        create an account
    </button>
    )

    const signUp = (
        <Fragment>
            <label htmlFor="firstName">First Name</label>
            <Field 
                type="text" 
                name="firstName"
                className="appearance-none relative block w-full px-3 py-2 border border-pink-500 bg-transparent text-pink-50 rounded-md focus:outline-none focus:ring-pink-500 focus:border-pink-500 focus:z-10 sm:text-sm"
            />
            <ErrorMessage name="firstName" component="p" />
            <label htmlFor="lastName">Last Name</label>
            <Field 
                type="text" 
                name="lastName"
                className="appearance-none relative block w-full px-3 py-2 border border-pink-500 bg-transparent text-pink-50 rounded-md focus:outline-none focus:ring-pink-500 focus:border-pink-500 focus:z-10 sm:text-sm"
            />
            <ErrorMessage name="lastName" component="p" />

        </Fragment>
    )

    return (

        <div className="min-h-full flex items-center justify-center py-12 px-4 sm:px-6 lg:px-8">
            <div className="max-w-md w-full space-y-8">
                <h2 className="mt-6 text-center text-3xl font-extrabold "> {isSignUpForm? "Create an account" : "Sign in to your account" }  </h2>
                <p className="mt-2 text-center text-sm">
                    Or {linkToForm}
                </p>

                <Formik
                    initialValues={{ firstName: '', lastName: '', email: '', password: '', }}
                    validate={values => {
                        const errors = {};
                        if (!values.email) {
                        errors.email = 'Required';
                        } else if (
                        !/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(values.email)
                        ) {
                        errors.email = 'Invalid email address';
                        }
                        return errors;
                    }}
                    onSubmit={(values, { setSubmitting }) => {
                        sendSignUpData(values)
                    }}
                >
                    {({ isSubmitting }) => (
                        <Form className="mt-8 space-y-6">
                            <div className="rounded-md shadow-sm text-left">

                                {isSignUpForm? signUp : null}

                                <label htmlFor="email">Email</label>
                                <Field 
                                    type="email" 
                                    name="email"
                                    className="appearance-none relative block w-full px-3 py-2 border border-pink-500 bg-transparent text-pink-50 rounded-md focus:outline-none focus:ring-pink-500 focus:border-pink-500 focus:z-10 sm:text-sm"/>
                                <ErrorMessage name="email" component="div" className="text-error text-sm font-bold p-2 pl-0" />
                                <label htmlFor="password">Password</label>
                                <Field 
                                    type="password" 
                                    name="password"
                                    className="appearance-none relative block w-full px-3 py-2 border border-pink-500 bg-transparent text-pink-50 rounded-md focus:outline-none focus:ring-pink-500 focus:border-pink-500 focus:z-10 sm:text-sm"/>
                                <ErrorMessage name="password" component="div" />
                                <button 
                                    type="submit" 
                                    disabled={isSubmitting}
                                    className="w-full flex justify-center mt-6 py-2 px-4 border border-transparent text-sm font-medium rounded-md text-pink-50 bg-pink-500 hover:bg-pink-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-pink-500"
                                >
                                    Submit
                                </button>
                            </div>
                        </Form>
                    )}
                </Formik>

            </div>
        </div>
    )

};
 
export default Signin;