import axios, { Axios, AxiosResponse } from "axios";
import { MovieDto } from "../models/movieDto";
import { GetMoviesResponse } from "../models/getMoviesResponse";


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
    }
}