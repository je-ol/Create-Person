import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const apiSlice = createApi({
    reducerPath: 'api',
    baseQuery: fetchBaseQuery({ baseUrl: 'http://localhost:5191' }),
    endpoints: (builder) => ({
        getPerson: builder.query({
            query: (id) => ({
                url: `/person/search/${id}`,
                method: 'GET',
            })
        
        }),
        createPerson: builder.mutation({
            query: (person) => ({
                url: '/person/new',
                method: 'POST',
                body: person,
            })
        })
    })
})
export const { useGetPersonQuery, useCreatePersonMutation, useLazyGetPersonQuery } = apiSlice;


