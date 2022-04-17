import axios from "axios";
import { Shape } from "../models/Shape";
import { Coord2D } from "../models/Coord2D";
import { Area2D } from "../models/Area2D";

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

export async function getShapesUnderPoint(point: Coord2D): Promise<Shape[]> {
    return new Promise((resolve, reject) => {
        axios.post("/api/shapes/underPoint", point).then((response) => {
            resolve(response.data as Shape[]);
        }, (err) => {
            reject(err);
        });
     });
}

export async function getShapesInsideArea(area: Area2D): Promise<Shape[]> {
    return new Promise((resolve, reject) => {
        axios.post("/api/shapes/insideArea", area).then((response) => {
            resolve(response.data as Shape[]);
        }, (err) => {
            reject(err);
        });
     });
}