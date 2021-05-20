import React from 'react';
import { VideoPlayer } from './VideoPlayer';
import  LiveVideoOptions  from './LiveVideoOptions';
import { Link } from 'react-router-dom';

export class Video extends React.Component {

    constructor(props) {
        super(props);            
      }    
 
    render() {
        const videoJsOptions = {
            autoplay: true,
            controls: true,
            sources: [{
                src: this.props.url,
                type: 'application/x-mpegURL'
            }]
        }
         console.log(this.props.url)
        return (
            <div className="video">

                <Link to={`/records/${this.props.streamId}`}><p>{this.props.name}</p></Link>
            
                <VideoPlayer {...videoJsOptions} />

                <LiveVideoOptions {...this.props}/>
            </div>
        )
    }
}