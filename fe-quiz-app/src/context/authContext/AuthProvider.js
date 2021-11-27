import React, { useReducer } from 'react';

import AuthContext from './AuthContext';
import AuthReducer from './AuthReducer';

const AuthProvider = (props) => {
    const initialState = {
        user: {}
    };

    const [state, dispatch] = useReducer(AuthReducer, initialState);

    // const sendAuthData = (authData) => { dispatch({ type: 'SET_USER_INFO', payload: authData })};
    
    return (
        <AuthContext.Provider
            value={{
                user: state.user,
                dispatch
            }}
        >
            {props.children}
        </AuthContext.Provider>
    );
};

export default AuthProvider