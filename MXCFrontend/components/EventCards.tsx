import React, { Component, useState } from 'react';
import { render } from 'react-dom';
import { useSession } from 'next-auth/react';
import { Event } from '../interfaces/index';
import { addEvent, deleteEvent, getEvents, getId } from '../pages/api/events/eventsAPI';
import { ReactDOM } from 'react';
import { useRouter } from 'next/router';
import Link from 'next/link';
import LoadingModal from './LoadingModal';
export default function EventCards({events}) {
    const {data: session, status } = useSession()
    const router = useRouter()
    const [isLoadingVisible, setLoadingVisible] = useState(false)
    
    setTimeout(() => {
        setLoadingVisible(false);
    }, 5000)
    
    return (
        <>
        {
            isLoadingVisible && (
                <LoadingModal/>
            )
        }
        
        <div className="p-10 grid grid-cols-1 sm:grid-cols-1 md:grid-cols-3 lg:grid-cols-3 xl:grid-cols-3 gap-5 dark:bg-slate-900">
           
       {
        session && (
        <a className="card">
            <h5>Create new Event</h5><br/>
            <p>Name: </p><input id="name" type="text" />
            <p>Location:</p><input id="location" maxLength={100} type="text" />
            <p>Country:</p><input id="country" type="text"  />
            <p>Capacity:</p><input id="capacity" type="number" />
                 
            <button className='submit' type='submit' onClick={(e) => {
                const id = Math.max(...events.map(o => o.id), 1) + 1;
                console.log(id)
                let event: Event = {
                    name: (document.getElementById("name")).value,
                    location: (document.getElementById("location")).value,
                    country: (document.getElementById("country")).value,
                    capacity: (document.getElementById("capacity")).value,
                    id: id
                }
                console.log(event)
                addEvent(event)
            }}>Create new</button>    
        </a>)
    }
    

        {
        session && (

        events.map((item: Event, visible: boolean) => (
        <a className="card">
            <h5>{item.name}</h5>
            <p>Location: {item.location}</p>
            <p>Country: {item.country}</p>
            <p>Capacity: {item.capacity}</p>
            <button className='delete' type='submit' onClick={(e) => {
                deleteEvent(item.id)
            }}>Delete</button>            
            <Link className='edit' href={`${item.id}`} >
            Modify
            </Link>
            </a>
        )))}
            
        
        { !events && (
            <p>You have no available events</p>
        )
        
        }
        { !session && (
            <p>You have to log in before modifying events!</p>
        )}
      
       
        </div>
        </>
    )
}
  