import axios from "axios";
import { Shape } from "../models/Shape";
import { Coord2D } from "../models/Coord2D";
import { Area2D } from "../models/Area2D";
import { AuthorizationResult } from "../models/AuthorizationResult";

export async function getShapes(): Promise<Shape[]> {
    let authorizationResult: AuthorizationResult = JSON.parse(localStorage.getItem('user')!);
    let config = {
        headers: {
            'Authorization': 'Bearer ' + authorizationResult?.token
        }
    }

    return new Promise((resolve, reject) => {
        axios.get("/api/shapes", config).then((response) => {
            resolve(response.data as Shape[]);
        }, (err) => {
            reject(err);
        });
    });
}

export async function createShape(shape: Shape): Promise<string> {
    let authorizationResult: AuthorizationResult = JSON.parse(localStorage.getItem('user')!);
    let config = {
        headers: {
            'Authorization': 'Bearer ' + authorizationResult?.token
        }
    }

    return new Promise((resolve, reject) => {
        axios.post("/api/shapes", shape, config).then((response) => {
            resolve(response.data as string);
        }, (err) => {
            reject(err);
        });
    });
}

export async function getShapesUnderPoint(point: Coord2D): Promise<Shape[]> {
    let authorizationResult: AuthorizationResult = JSON.parse(localStorage.getItem('user')!);
    let config = {
        headers: {
            'Authorization': 'Bearer ' + authorizationResult?.token
        }
    }

    return new Promise((resolve, reject) => {
        axios.post("/api/shapes/underPoint", point, config).then((response) => {
            resolve(response.data as Shape[]);
        }, (err) => {
            reject(err);
        });
    });
}

export async function getShapesInsideArea(area: Area2D): Promise<Shape[]> {
    let authorizationResult: AuthorizationResult = JSON.parse(localStorage.getItem('user')!);
    let config = {
        headers: {
            'Authorization': 'Bearer ' + authorizationResult?.token
        }
    }

    return new Promise((resolve, reject) => {
        axios.post("/api/shapes/insideArea", area, config).then((response) => {
            resolve(response.data as Shape[]);
        }, (err) => {
            reject(err);
        });
    });
}