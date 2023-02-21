
import Layout from '../components/Layout'
import { getEvent, getEvents, modifyEvent } from './api/events/eventsAPI';

import { useRouter } from 'next/router';
import {Event} from '../interfaces/index';
import { useEffect } from 'react';

export default function EditPage(props: {event: Event})
{
        const router = useRouter()

        console.log(router.query)
        return (
                    <Layout>
                    <a className="card">
                    <h5>Modify event</h5><br/>
                    <p>Name: </p><input id="name" type="text" defaultValue={props.event.name}/>
                    <p>Location:</p><input id="location" type="text" defaultValue={props.event.location} />
                    <p>Country:</p><input id="country" type="text" defaultValue={props.event.country} />
                    <p>Capacity:</p><input id="capacity" type="text" defaultValue={props.event.capacity} />
               
                    <button className='submit' type='submit' onClick={(e) => {
                        let eventCopy: Event = {
                            name: (document.getElementById("name")).value,
                            location: (document.getElementById("location")).value,
                            country: (document.getElementById("country")).value,
                            capacity: (document.getElementById("capacity")).value,
                            id: Number(props.event.id)
                        }
                        console.log(props.event.id)
                        console.log(eventCopy)
                        modifyEvent(Number(props.event.id), eventCopy)
                        alert("Successful modification!")
                       
                    }}>Modify</button>    
                </a>
                    </Layout>
            
        )        
    
    

} 

async function modifyEventAsync(id, copy: Event)
{
    const res = await modifyEvent(id, copy)
    return { res }
}

export async function getServerSideProps(id) {
    const event = await getEvent(Number(id.query.event));
    return { props: {event} };
  }
  