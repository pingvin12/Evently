import React, { Component } from "react";
import Switch from "react-switch";

class ThemeToggleSwitch extends Component {
   constructor(props: any) {
    super(props);
    this.state = { dark : false};
    this.handleChange = this.handleChange.bind(this);
   }

   handleChange(checked: boolean) {
    if (document.documentElement.classList.contains('dark')){
        this.setState({dark: checked})
        document.documentElement.classList.remove('dark')
    }
    else {
        this.setState({dark: checked})
        document.documentElement.classList.add('dark')
    }
   }

    render() {
        return (<label htmlFor="default-toggle" className="inline-flex relative items-end cursor-pointer">
                <Switch onChange={this.handleChange} checked={this.state.dark} />
                
                <span className="ml-3 text-sm font-medium text-gray-900 dark:text-gray-300">Set theme to light/dark</span>
            </label>
        );
    }
}

export default ThemeToggleSwitch;
