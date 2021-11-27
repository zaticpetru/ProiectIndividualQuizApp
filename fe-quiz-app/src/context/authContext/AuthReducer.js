import * as actionTypes from './actionTypes';

const updateStateObject = (oldObject, updatedProprieties) => {
    return {
        ...oldObject,
        ...updatedProprieties
    };
};

const setUserInfo = ( state, action ) => {
    console.log(action.payload)
    return updateStateObject( state, {
        user: action.payload
    } );
};


const AuthReducer = ( state, action ) => {
    switch ( action.type ) {
        case actionTypes.SET_USER_INFO: return setUserInfo(state, action);
        default:
            return state;
    }
};

export default AuthReducer;