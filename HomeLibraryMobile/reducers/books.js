import createReducer from '../lib/createReducer'
import * as types from '../actions/types'

export const selectedBook = createReducer({ author: '', title: ''}, {
    [types.SELECT_BOOK](state, action){
        return action.selectedBook;
    }
});

export const signalRState = createReducer('disconnected',{
    [types.SIGNALR_STATE_CHANGED](state, action){
        return action.signalRState;
    }
})

export const libraryState = createReducer({books: []}, {
    [types.UPDATE_LIBRARY_STATE](state, action){
        return action.libraryState;
    }
})

export const books = createReducer([], {
    [types.UPDATE_LIBRARY_STATE](state, action){
        return action.libraryState.books;
    }
})