using AutoMapper;

namespace tourney.api.Mappers;

public class DynamicMapper
{
    private readonly IMapper _mapper;

    public DynamicMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TDestination Map<TSource, TDestination>(TSource source)
    {
        return _mapper.Map<TSource, TDestination>(source);
    }

}