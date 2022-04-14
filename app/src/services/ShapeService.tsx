import axios from "axios";
import { Shape } from "../models/Shape";

export async function getShapes(): Promise<Shape[]> {
    return new Promise((resolve, reject) => {
        axios.get("/api/shapes").then((response) => {
            resolve(response.data as Shape[]);
        }, (err) => {
            reject(err);
        });
     });
}

export async function createShape(shape: Shape): Promise<string> {
    return new Promise((resolve, reject) => {
        axios.post("/api/shapes", shape).then((response) => {
            resolve(response.data as string);
        }, (err) => {
            reject(err);
        });
     });
}