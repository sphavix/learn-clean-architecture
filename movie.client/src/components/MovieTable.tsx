import { useEffect, useState } from "react"
import { MovieDto } from "../models/movieDto"
import apiConnector from "../api/apiConnector";
import { Container } from "semantic-ui-react";


export default function MovieTable(){

    const [movies, setMovies] = useState<MovieDto[]>([]);

    useEffect(() =>{
        const fetchMovies = async () => {
            const fetchedMovies = await apiConnector.getMovies();
            setMovies(fetchedMovies);
        }
        fetchMovies();
    }, []);

    return(

        <>
           
        </>
    )
}