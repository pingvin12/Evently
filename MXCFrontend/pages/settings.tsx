import Link from 'next/link'
import Layout from '../components/Layout'
import ThemeToggleSwitch from '../components/themeswitcher'

const Settings = () => (
  <Layout>
    <div className='dark:bg-slate-900 h-[900px] py-20'>
    <ThemeToggleSwitch/>
    </div>
  </Layout>
)

export default Settings
