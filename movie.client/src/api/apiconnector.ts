import axios, { Axios, AxiosResponse } from "axios";
import { MovieDto } from "../models/movieDto";
import { GetMoviesResponse } from "../models/getMoviesResponse";
import { GetMovieByIdResponse } from "../models/getMovieByIdResponse";


const API_BASE_URL = 'http://localhost:5136';
const apiConnector = {
    getMovies: async (): Promise<MovieDto[]> => {
        try
        {
            const response: AxiosResponse<GetMoviesResponse> = 
                await axios.get(`${API_BASE_URL}/movies`);
            const movies = response.data.movieDto.map(movie => ({
                ...movie, releaseyear: movie.releaseyear?.slice(0,10) ?? ""
            }));
            return movies;
        }
        catch(error)
        {
            console.log('Error getting movie reviews', error);
            throw error;
        }
    },

    createMovie: async (movie: MovieDto): Promise<void> => {
        try{
            await axios.post<number>(`${API_BASE_URL}/movies`, movie);
        }
        catch(error){
            console.log(error);
            throw error;
        }
    },

    editMovie: async (movie: MovieDto): Promise<void> => {
        try{
            await axios.put<number>(`${API_BASE_URL}/movies`, movie);
        }
        catch(error){
            console.log(error);
            throw error;
        }
    },

    deleteMovie: async (movieId: string): Promise<void> => {
        try{
            await axios.delete<number>(`${API_BASE_URL}/movies/${movieId}`);
        }
        catch(error){
            console.log(error);
            throw error;
        }
    },

    getMovieById: async (movieId: string): Promise<MovieDto | undefined> => {
       try{
            const response = await axios.get<GetMovieByIdResponse>(`${API_BASE_URL}/movies/${movieId}`);
            return response.data.movieDto;
       }catch(error){
            console.log(error);
            throw error;
        }
    }
}

export default apiConnector;