import axios from "axios";
import { AuthorizationResult } from "../models/AuthorizationResult";
import { User } from "../models/User";

export async function authorize(user: User): Promise<AuthorizationResult> {
    return new Promise((resolve, reject) => {
        axios.post("/api/users/authorize", user).then((response) => {
            resolve(response.data as AuthorizationResult);
        }, (err) => {
            reject(err);
        });
     });
}