import Layout from '../components/Layout'
import { useSession } from 'next-auth/react';
import Image from 'next/image';

export default function Profile() {
  const {data: session, status } = useSession()
  return(

  <Layout>
    <div className="p-10 grid grid-cols-1 sm:grid-cols-1 md:grid-cols-3 lg:grid-cols-3 xl:grid-cols-3 gap-5">
    {
      session && (
        
          <a className="card">
            <h5>{session.user.name}</h5><br/>
            <Image src={session?.user.image} width={500} height={500} alt='avatar' className='full-pic'></Image><br/>
            <p>Email: {session.user.email}</p>
          </a>
        
      )
    }
    </div>
  </Layout>
)
}