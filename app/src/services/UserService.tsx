import axios from "axios";
import { AuthorizationResult } from "../models/AuthorizationResult";
import { User } from "../models/User";

export async function authorize(user: User): Promise<AuthorizationResult> {
    let config = {
        headers: {
            'Access-Control-Allow-Origin' : '*'
        }
    }

    return new Promise((resolve, reject) => {
        axios.post(process.env.REACT_APP_USERS_API! + "/authorize", user, config).then((response) => {
            resolve(response.data as AuthorizationResult);
        }, (err) => {
            reject(err);
        });
     });
}