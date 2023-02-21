import Link from 'next/link'
import Layout from '../components/Layout'
import { getEvents } from './api/events/eventsAPI';
import EventCards from '../components/EventCards';
import { getSession } from 'next-auth/react';
export default function IndexPage(props: {event})
{

  const usr = getSession()
return (
  <Layout>
    <EventCards events={props.event} />
  </Layout>
)

} 
export async function getServerSideProps() {
  const event = await getEvents();
  return { props: {event} };
}
