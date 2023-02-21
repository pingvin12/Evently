import axios from 'axios';
import https from 'https';
import {Event} from '../../../interfaces/index';
const API_URL = process.env.BACKENDPATH;

const axiosInstance = axios.create({
  baseURL: API_URL,
  httpsAgent: new https.Agent({  
    rejectUnauthorized: false
  })
});

export const getEvents = async () => {
  const res = await axiosInstance.get(`${API_URL}Event/AllEvents`);
  return res.data;
};

export const getEvent = async (id: number) => {
  const res = await axiosInstance.get(`${API_URL}Event/${id}`)
  return res.data;
}

export const addEvent = async (event: Event) => {
  const res = await axiosInstance.post(`${API_URL}Event`, event);
  return res.data;
};

export const modifyEvent = async (id: number, event: Event) => {
  const res = await axiosInstance.put(`${API_URL}Event/${id}`, event);
  return res.data;
}

export const deleteEvent = async (id: number) => {
  console.log(id)
  const res = await axiosInstance.delete(`${API_URL}Event/${id}`);
  console.log(res.data)
  return res.data;
};

export const getId = async () => {
  const res = await axiosInstance.get(`${API_URL}Event/temp`)
  return res.data;
}